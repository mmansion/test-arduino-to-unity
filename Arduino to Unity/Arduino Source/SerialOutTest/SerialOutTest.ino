long lastSendTime = 0;
int sendDelayTime = 2000;

void setup() {
  // initialize serial communications at 9600 bps:
  Serial.begin(9600);
}

void loop() {

  if(millis() - lastSendTime > sendDelayTime) {
    lastSendTime = millis();
    Serial.println(1);
    
  }
}
