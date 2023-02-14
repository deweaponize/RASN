#define trigPin A0
#define sensors sizeof(echoPins) / sizeof(echoPins[0])

const int echoPins[] = {A1, A2, A3, A4, A5, A6};
const int sennsorCount = sensors;

void setup()
{
    Serial.begin(9600);
    pinMode(trigPin, OUTPUT);
    for (int i = 0; i < 5; i++)
    {
        pinMode(echoPins[i], INPUT);
    }
}

void loop()
{
    for (int i = 0; i < sennsorCount; i++)
    {
        reset();
        unsigned int distance = measureDistance(echoPins[i]);
        print(i, distance);
    }
    delay(60);
}

unsigned int measureDistance(int echoPin)
{
    unsigned int duration = pulseIn(echoPin, HIGH);
    unsigned int distance = (duration / 2) / 29.1;
    return distance;
}

void reset()
{
    digitalWrite(trigPin, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);
}
void print(int sensor_number, unsigned int distance)
{
    Serial.print("Sensor");
    Serial.print(sensor_number + 1);
    Serial.print("  ");
    Serial.print(distance);
    Serial.println("cm");
}

// #define trigPin A0  //for triggering trigger pin
// const int echoPins[] = {A1, A2, A3, A4, A5};  //echopins for the ultrasonic sensors

// void setup() {
//   Serial.begin(9600);
//   pinMode(trigPin, OUTPUT);
//   for (int i = 0; i < 5; i++) {
//     pinMode(echoPins[i], INPUT);
//   }
// }

// void loop() {
//   // Read the distance from each sensor
//   for (int i = 0; i < 5; i++) {
//     long distance = measureDistance(echoPins[i]);
//     Serial.print("Sensor");
//     Serial.print(i + 1);
//     Serial.print("  ");
//     Serial.print(distance);
//     Serial.println("cm");
//   }
//   delay(60);  // delay at least 60ms between measurements
// }

// long measureDistance(int echoPin) {
//   // Trigger the ultrasonic sensor
//   digitalWrite(trigPin, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin, LOW);

//   // Measure the distance
//   long duration = pulseIn(echoPin, HIGH);
//   long distance = (duration / 2) / 29.1;
//   return distance;
// }

// #define trigPin1 A0  //for triggering trigger pin
// #define echoPin1 A1  //echopin for US1
// #define echoPin2 A2  //echopin for US2
// #define echoPin3 A3  //echopin for US3
// #define echoPin4 A4  //echopin for US4
// #define echoPin5 A5  //echopin for US5

// void setup() {
//   Serial.begin(9600);
//   pinMode(trigPin1, OUTPUT);
//   pinMode(echoPin1, INPUT);
//   pinMode(echoPin2, INPUT);
//   pinMode(echoPin3, INPUT);
//   pinMode(echoPin4, INPUT);
//   pinMode(echoPin5, INPUT);

// }

// void loop() {
//   //1--------------------------------------------------
//   long duration1, distance1;
//   digitalWrite(trigPin1, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin1, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin1, LOW);
//   duration1 = pulseIn(echoPin1, HIGH);
//   distance1 = (duration1 / 2) / 29.1;
//   Serial.print("Sensor1  ");
//   Serial.print(distance1);
//   Serial.println("cm");
//   delay(40);
//   //2--------------------------------------------------
//   long duration2, distance2;
//   digitalWrite(trigPin1, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin1, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin1, LOW);
//   duration2 = pulseIn(echoPin2, HIGH);
//   distance2 = (duration2 / 2) / 29.1;
//   Serial.print("Sensor2  ");
//   Serial.print(distance2);
//   Serial.println("cm");
//   delay(40);
//   //3--------------------------------------------------
//   long duration3, distance3;
//   digitalWrite(trigPin1, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin1, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin1, LOW);
//   duration3 = pulseIn(echoPin3, HIGH);
//   distance3 = (duration3 / 2) / 29.1;
//   Serial.print("Sensor3  ");
//   Serial.print(distance3);
//   Serial.println("cm");
//   delay(40);
//   //4--------------------------------------------------
//   long duration4, distance4;
//   digitalWrite(trigPin1, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin1, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin1, LOW);
//   duration4 = pulseIn(echoPin4, HIGH);
//   distance4 = (duration4 / 2) / 29.1;
//   Serial.print("Sensor4  ");
//   Serial.print(distance4);
//   Serial.println("cm");
//   delay(40);
//   //5--------------------------------------------------
//   long duration5, distance5;
//   digitalWrite(trigPin1, LOW);
//   delayMicroseconds(2);
//   digitalWrite(trigPin1, HIGH);
//   delayMicroseconds(10);
//   digitalWrite(trigPin1, LOW);
//   duration5 = pulseIn(echoPin5, HIGH);
//   distance5 = (duration5 / 2) / 29.1;
//   Serial.print("Sensor5  ");
//   Serial.print(distance5);
//   Serial.println("cm");
//   delay(40);
// }
