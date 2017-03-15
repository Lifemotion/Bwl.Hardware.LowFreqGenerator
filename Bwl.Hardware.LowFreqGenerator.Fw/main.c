#define DEV_NAME "LowFreq Gen 1.0"

#include "board/board.h"
#include "refs-avr/winstar1602.h"
#include "refs-avr/bwl_strings.h"
#include "refs-avr/bwl_uart.h"
#include "refs-avr/bwl_simplserial.h"

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

byte sequence[256];
byte seq_length=0;
byte seq_autoplay=0;
byte seq_position=0;

void sserial_process_request(unsigned char portindex)
{
	if (sserial_request.command==45)
	{
		for (int i=0; i<sserial_request.datalength; i++)
		{
			sequence[i]=sserial_request.data[i];
			if (sserial_request.data[i]==0) {seq_length=i;}
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
			var_delay_us(100);
			}
		//timer0_setvalue(0);
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}	
	
	if (sserial_request.command==65)
	{
		byte seq_autoplay=1;
		byte seq_position=0;
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}	
	
	if (sserial_request.command==66)
	{
		byte seq_autoplay=0;
		byte seq_position=0;
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=1;
		sserial_send_response();
	}	
}

void sserial_init()
{
	uart_init_withdivider(UART_USB,UBRR_VALUE);
	sserial_find_bootloader();
	sserial_set_devname(DEV_NAME);
	sserial_append_devname(16,12,__DATE__);
	sserial_append_devname(27,8,__TIME__);
}


int main(void)
{
	wdt_enable(WDTO_8S);
	board_init();
	sserial_init();
	lcd_init();
	show_device_info();
	setbit(DDRB,4,1);
	setbit(PORTB,4,1);
	timer0_setup();
	timer0_setvalue(10);
	while(1)
	{
		/*if (get_button_1()) {lcd_string_to_linebuffer("Button 1"); lcd_writebuffer();}
		if (get_button_2()) {lcd_string_to_linebuffer("Button 2"); lcd_writebuffer();}
		if (get_button_3()) {lcd_string_to_linebuffer("Button 3"); lcd_writebuffer();}
		if (get_button_4()) {lcd_string_to_linebuffer("Button 4"); lcd_writebuffer();}
		for (int i=0; i<255; i++)
		{
			timer0_setvalue(255-i);
			var_delay_us(100);
		}*/
		wdt_reset();
		sserial_poll_uart(0);
	}
}