#define trigPin1 A0 // for triggering trigger pin
#define echoPin1 A1 // echopin for US1
#define echoPin2 A2 // echopin for US2
#define echoPin3 A3 // echopin for US3
#define echoPin4 A4 // echopin for US4
#define echoPin5 A5 // echopin for US5
//----------------------------------Ultra Sonic
int s1 = 11; // sensor 1 input
int s2 = 12; // sensor 2 input
int s3 = 13; // sensor 3 input
int s4 = 14; // sensor 4 input
int s5 = 15; // sensor 5 input
int s6 = 16; // sensor 6 input

int S1V = 0; // sensor 1 data
int S2V = 0; // sensor 2 data
int S3V = 0; // sensor 3 data
int S4V = 0; // sensor 4 data
int S5V = 0; // sensor 5 data
int S6V = 0; // sensor 6 data
//----------------------------------IR
int s1 = 7;  // sensor 1 input
int s2 = 8;  // sensor 2 input
int s3 = 9;  // sensor 3 input
int s4 = 10; // sensor 4 input
int s5 = 11; // sensor 5 input
int s6 = 12; // sensor 6 input

int S1V = 0; // sensor 1 data
int S2V = 0; // sensor 2 data
int S3V = 0; // sensor 3 data
int S4V = 0; // sensor 4 data
int S5V = 0; // sensor 5 data
int S6V = 0; // sensor 6 data

void setup()
{
    Serial.begin(9600);
    pinMode(trigPin1, OUTPUT);
    pinMode(echoPin1, INPUT);
    pinMode(echoPin2, INPUT);
    pinMode(s1, INPUT);
    pinMode(s2, INPUT);
    pinMode(s3, INPUT);
    pinMode(s4, INPUT);
    pinMode(s5, INPUT);
    pinMode(s6, INPUT);
}

void loop()
{
    // low means no edge:: high means edge detected

    S1V = digitalRead(s1);
    S2V = digitalRead(s2);
    S3V = digitalRead(s3);
    S4V = digitalRead(s4);
    S5V = digitalRead(s5);
    S6V = digitalRead(s6);

    // sensor1----------------------------
    if (S1V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S1V == HIGH)
    {
        Serial.println("edge on 1");
        delay(400);
    }
    // sensor2   -----------------------------

    if (S2V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S2V == HIGH)
    {
        Serial.println("edge on 2");
        delay(400);
    }
    // sensor3  ----------------------
    if (S3V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S3V == HIGH)
    {
        Serial.println("edge on 3");
        delay(400);
    }
    // sensor4----------------------------
    if (S4V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S4V == HIGH)
    {
        Serial.println("edge on 4 ");
        delay(400);
    }
    // sensor5 --------------------------------
    if (S5V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S5V == HIGH)
    {
        Serial.println("edge on 5");
        delay(400);
    }
    // sensor6 --------------------------------------------
    if (S6V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    else if (S6V == HIGH)
    {
        Serial.println("edge on 6");
        delay(400);
    }

    // 1--------------------------------------------------
    long duration1, distance1;
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration1 = pulseIn(echoPin1, HIGH);
    distance1 = (duration1 / 2) / 29.1;
    Serial.print("Sensor1  ");
    Serial.print(distance1);
    Serial.println("cm");
    delay(40);
    // 2--------------------------------------------------
    long duration2, distance2;
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration2 = pulseIn(echoPin2, HIGH);
    distance2 = (duration2 / 2) / 29.1;
    Serial.print("Sensor2  ");
    Serial.print(distance2);
    Serial.println("cm");
    delay(40);
    // 3--------------------------------------------------
    long duration3, distance3;
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration3 = pulseIn(echoPin3, HIGH);
    distance3 = (duration3 / 2) / 29.1;
    Serial.print("Sensor3  ");
    Serial.print(distance3);
    Serial.println("cm");
    delay(40);
    // 4--------------------------------------------------
    long duration4, distance4;
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration4 = pulseIn(echoPin4, HIGH);
    distance4 = (duration4 / 2) / 29.1;
    Serial.print("Sensor4  ");
    Serial.print(distance4);
    Serial.println("cm");
    delay(40);
    // 5--------------------------------------------------
    long duration5, distance5;
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration5 = pulseIn(echoPin5, HIGH);
    distance5 = (duration5 / 2) / 29.1;
    Serial.print("Sensor5  ");
    Serial.print(distance5);
    Serial.println("cm");
    delay(40);
    //-----------------------IR---------------------------
    // low means no edge:: high means edge detected

    S1V = digitalRead(s1);
    S2V = digitalRead(s2);
    S3V = digitalRead(s3);
    S4V = digitalRead(s4);
    S5V = digitalRead(s5);
    S6V = digitalRead(s6);

    if (S1V == LOW && S2V == LOW && S3V == LOW && S4V == LOW && S5V == LOW && S6V == LOW)
    {
        Serial.println("NO edge");
        delay(400);
    }
    if ()
}
