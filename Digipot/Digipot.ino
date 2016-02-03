#include <SPI.h>

short receivedVal;      // receive values back from SDO of AD5292
  
short digiPotSetup[2] = { 0x1802,   // Enable update of wiper position through digital interface
                          0x0400,   // Write 0x100 to the RDAC register; wiper moves to 1/4 full-scale position
                        };
short powerOn = 0x2000;
int i = 0;
const int slaveSelectPin = 10;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);     // Activate a Serial Monitor to look at SDO output
  pinMode(slaveSelectPin, OUTPUT);

  /*
   * SPI Speed:     20000000 Hz
   * SPI Bit Order: MSBFIRST
   * SPI Mode:      SPI MODE 1, CPOL = 0, CPHA = 1
   */
  SPI.setBitOrder(MSBFIRST);
  //SPI.setClockDivider(SPI_CLOCK_DIV1);
  SPI.setDataMode(SPI_MODE1);
  SPI.begin();
  
//  digitalWrite(slaveSelectPin, LOW);
//  receivedVal = (SPI.transfer(powerOn >> 8) << 8) & 0xFF;    // Power on the DigiPot
//  receivedVal = SPI.transfer(powerOn);                       // Power on the DigiPot
//  digitalWrite(slaveSelectPin, HIGH);
//  Serial.print("Pushed value is: ");
//  Serial.println(receivedVal, HEX);
//
//  delay(100);

  digitalWrite(slaveSelectPin, LOW);
  receivedVal = (SPI.transfer(digiPotSetup[0] >> 8) << 8) & 0xFF;    // Power on the DigiPot
  receivedVal = SPI.transfer(digiPotSetup[0]);                       // Power on the DigiPot
  digitalWrite(slaveSelectPin, HIGH);
  Serial.print("Pushed value is: ");

  delay(100);

  digitalWrite(slaveSelectPin, LOW);
  receivedVal = (SPI.transfer(digiPotSetup[1] >> 8) << 8) & 0xFF;    // Power on the DigiPot
  receivedVal = SPI.transfer(digiPotSetup[1]);    // Power on the DigiPot
  digitalWrite(slaveSelectPin, HIGH);
  Serial.print("Pushed value is: ");
}

void loop() {
  // put your main code here, to run repeatedly:
/*
  digitalWrite(slaveSelectPin, LOW);
  delayMicroseconds(1);
  digitalWrite(slaveSelectPin, HIGH);  
  delayMicroseconds(1);
 */ 

  if(i < 1024)
  {
    delay(100);
    
    digitalWrite(slaveSelectPin, LOW);
    receivedVal = (SPI.transfer((digiPotSetup[1]+i) >> 8) << 8) & 0xFF;    // Power on the DigiPot
    receivedVal = SPI.transfer(digiPotSetup[1]+i);    // Power on the DigiPot
    digitalWrite(slaveSelectPin, HIGH);  
    i++;
  }
  
  // End SPI when i = 1024
  if(i >= 1024)
    SPI.end();
}
