#define DEV_NAME "LowFreq Gen 1.1"
#include <avr/interrupt.h>


#include "board/board.h"
#include "refs-avr/winstar1602.h"
#include "refs-avr/bwl_strings.h"
#include "refs-avr/bwl_uart.h"
#include "refs-avr/bwl_simplserial.h"
#include "refs-avr/bwl_i2c.h"
#include "refs-avr/h3lis331.h"

void show_device_info()
{
	string_clear();
	string_add_string(DEV_NAME);
	lcd_stringbuffer_to_linebuffer(0);
	lcd_writebuffer();
}

void board_init()
{
	power_internal(0);
	var_delay_ms(500);
	power_internal(1);
	get_button_1();
	get_button_2();
	get_button_3();
	get_button_4();
}

void timer0_setup()
{
	TCCR0A=(0<<COM0B0)|(1<<COM0B1)|(0<<WGM01)|(1<<WGM00);
	TCCR0B=(0<<CS02)|(0<<CS01)|(1<<CS00)|(0<<WGM02);
}

void timer0_setvalue(byte value)
{
	OCR0B=value;
}

void sserial_send_start(unsigned char portindex){};//{if (portindex==UART_485)	{DDRB|=(1<<6);PORTB|=(1<<6);}}

void sserial_send_end(unsigned char portindex){};//{if (portindex==UART_485)	{DDRB|=(1<<6);PORTB&=(~(1<<6));}}
unsigned char pointer = 0;
byte sequence[256];
byte seq_length=0;
byte seq_autoplay=0;
byte seq_position=0;
uint16_t seq_sample_length=0;
unsigned long start_delay = 0;
void sserial_process_request(unsigned char portindex)
{
	
	if(sserial_request.command == 10){
		if(sserial_request.datalength>0){
			h3lis331_init(sserial_request.data[0]);
		}
		sserial_response.datalength = 100;
		sserial_response.result = 200;
		sserial_send_response();
	}

	if (sserial_request.command==45)
	{
		seq_sample_length=(((uint16_t)sserial_request.data[1])<<8)+((uint16_t)sserial_request.data[2]);
		seq_autoplay=0;
		cli();
		seq_length=sserial_request.datalength-8;
		
		for (int i=8; i<sserial_request.datalength; i++)
		{
			sequence[i-8]=sserial_request.data[i];
		}
		
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}
	
	if (sserial_request.command==55)
	{
		for (int i=0; i<seq_length; i++)
		{
			timer0_setvalue(sequence[i]);
			var_delay_us(seq_sample_length);
		}
		//timer0_setvalue(0);
		seq_autoplay=0;
		seq_position=0;
		cli();
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}
	
	if (sserial_request.command==65)
	{
		seq_autoplay=1;
		sei();
		start_delay = 0;
		pointer=0;
		seq_position=0;
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}
	
	if (sserial_request.command==66)
	{
		seq_autoplay=0;
		seq_position=0;
		cli();
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}
}

void sserial_init()
{
	uart_init_withdivider(UART_USB,UBRR_VALUE);
	sserial_find_bootloader();
	sserial_set_devname("LowFreq Gen 1.1");
	sserial_append_devname(16,12,__DATE__);
	sserial_append_devname(27,8,__TIME__);
}

void timer1_setup()
{
	TCCR1B =  (1 << CS11);
	TIMSK1 =  (1 << TOIE1);
}


unsigned char resonanse_scanning = 0;
ISR(TIMER1_OVF_vect)
{
	cli();
	if(resonanse_scanning)
	{

	}else{

		
	if (seq_autoplay!=0){
			timer0_setvalue(sequence[seq_position]);
			seq_position+=1;
			if(seq_position==pointer)
			{
				if(pointer<100){
					h3lis331_refresh_data();
					sserial_response.data[pointer] = (unsigned char)((h3lis331_data.z_axis)*5+128);
				}			
			}
			if (seq_position>=seq_length){seq_position=0;pointer++;}
			if(pointer>100)pointer=0;
		}
	}
	TCNT1 = 65534-seq_sample_length*2;
	sei();
}

int main(void)
{
	cli();
	wdt_enable(WDTO_8S);
	board_init();
	sserial_init();
	lcd_init();
	show_device_info();
	setbit(DDRB,4,1);
	setbit(PORTB,4,1);
	PORTC	 |=(1<<PORTC0);
	PORTC	 |=(1<<PORTC1);
	TWSR = 0;
	TWBR = 62;
	h3lis331_init(H3LIS331_100g_SCALE);
	timer0_setup();
	timer1_setup();
	while(1)
	{
		sserial_poll_uart(0);
		wdt_reset();
	}
}