#ifndef HMC5983_H_
#define HMC5983_H_

typedef struct
{
	unsigned int x;
	unsigned int y;
	unsigned int z;
} mag_data_t;

typedef unsigned char byte;

#define LSM_AVERAGING_1 0b00000000
#define LSM_AVERAGING_2 0b00100000
#define LSM_AVERAGING_4 0b01000000
#define LSM_AVERAGING_8 0b01100000

#define LSM_DATARATE_50			0b00000000
#define LSM_DATARATE_100		0b00001000
#define LSM_DATARATE_400		0b00010000
#define LSM_DATARATE_1000		0b00011000

#define LSM_GAIN_8		0b00000000
#define LSM_GAIN_7		0b00100000
#define LSM_GAIN_6		0b01000000
#define LSM_GAIN_5		0b01100000
#define LSM_GAIN_4		0b10000000
#define LSM_GAIN_3		0b10100000
#define LSM_GAIN_2		0b11000000
#define LSM_GAIN_1		0b11100000

#define  LSM_MEASHUREMENT_NORMAL	0b00000000

#define  LSM_MODE_NORMAL		0b00100111 //39
#define  LSM_MODE_POWERDOWN		0b00000000

//необходимо реализовать
void i2c_wait();
void i2c_start() ;
void i2c_write_byte(char byte);
char i2c_read_byte();
char i2c_read_last_byte();
void i2c_stop();

//можно использовать
void lsm_read_temp(volatile unsigned int * data);
void lsm_read_raw(unsigned char * data);
mag_data_t lsm_read();
void lsm_init(byte averaging_code, byte datarate_code, byte gain_code);
void lsm_sleep();
byte lsm_averaging_to_code(byte averaging);
byte lsm_gain_to_code(byte gain);

#endif /* HMC5983_H_ */