/*
 * h3lis331.c
 *
 * Created: 26.06.2017 23:57:05
 *  Author: gus10
 */ 
 #include "h3lis331.h"
 unsigned char device_address = 0x33;
 float mux_value = 100.0/32768.0;

 void h3lis331_init(unsigned char scale)
 {
	i2c_start();
	i2c_write_byte(device_address & ~(0x01));
	i2c_write_byte(0x20);
	i2c_write_byte(0x3f);
	i2c_stop();
	i2c_start();
	i2c_write_byte(device_address & ~(0x01));
	i2c_write_byte(0x23);
	switch(scale){
		case 1:
			i2c_write_byte(0x90);
			mux_value = 200.0/32768.0;
			break;
		case 2:
			i2c_write_byte(0xB0);
			mux_value = 400.0/32768.0;
			break;
		default:
			i2c_write_byte(0x00);
			mux_value = 100.0/32768.0;
	}
	i2c_stop();
 }

void h3lis331_refresh_data()
{
	i2c_start();
	i2c_write_byte(device_address & ~(0x01));
	i2c_write_byte(0xA8);
	i2c_start();
	i2c_write_byte(device_address | (0x01));
	h3lis331_data.x_axis = ((int)(i2c_read_byte()|i2c_read_byte()<<8))*mux_value;
	h3lis331_data.y_axis = ((int) (i2c_read_byte()|i2c_read_byte()<<8))*mux_value;
	h3lis331_data.z_axis = ((int)(i2c_read_byte()|i2c_read_last_byte()<<8))*mux_value;
	i2c_stop();
}

void h3lis331_fill_data_array(unsigned char *data)
{
	i2c_start();
	i2c_write_byte(device_address & ~(0x01));
	i2c_write_byte(0xA8);
	i2c_start();
	i2c_write_byte(device_address | (0x01));
	for(unsigned char i=0; i<5;i++){
		*data++ = i2c_read_byte();
	}
	*data++ = i2c_read_last_byte();
	i2c_stop();
}