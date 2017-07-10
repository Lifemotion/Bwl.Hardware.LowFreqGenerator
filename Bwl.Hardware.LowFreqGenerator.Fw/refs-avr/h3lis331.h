/*
 * h3lis331.h
 *
 * Created: 26.06.2017 23:57:19
 *  Author: gus10
 */ 


#ifndef H3LIS331_H_
#define H3LIS331_H_

#define H3LIS331_100g_SCALE 0
#define H3LIS331_200g_SCALE 1
#define H3LIS331_400g_SCALE 2

struct
{
	float z_axis;
	float x_axis;
	float y_axis;
} h3lis331_data;

void h3lis331_init(unsigned char scale);
void h3lis331_refresh_data();
void h3lis331_fill_data_array(unsigned char *data);

//need to realise
void i2c_start() ;
void i2c_write_byte(char byte) ;
char i2c_read_byte() ;
char i2c_read_last_byte() ;
void i2c_stop();

#endif /* H3LIS331_H_ */