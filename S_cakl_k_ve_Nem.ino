#include <Wire.h>
#include <DHT.h>
#define DHTPIN 2
#define DHTTYPE DHT11
DHT dht (DHTPIN, DHTTYPE);
void setup() 
{
  dht.begin();
  Serial.begin(9600);
}

void loop() 
{
  int temp = dht.readTemperature();
  int hum = dht.readHumidity();
  Serial.println(temp);
  Serial.println(hum);
  delay(2000);
}
