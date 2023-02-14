const int sensors[6] = {s1, s2, s3, s4, s5, s6};
unsigned long previousMillis = 0;
const long interval = 400; // read sensors every 400 ms

void loop()
{
    unsigned long currentMillis = millis();
    if (currentMillis - previousMillis >= interval)
    {
        for (int i = 0; i < 6; i++)
        {
            int S_V = digitalRead(sensors[i]);
            if (S_V == LOW)
            {
                Serial.println("NO edge");
            }
            else if (S_V == HIGH)
            {
                Serial.print("edge on ");
                Serial.println(i + 1);
            }
        }
        previousMillis = currentMillis;
    }
    // other tasks go here
}

// int s1 = 7;  //sensor 1 input
// int s2 = 8;  //sensor 2 input
// int s3 = 9;  //sensor 3 input
// int s4 = 10;  //sensor 4 input
// int s5 = 11;  //sensor 5 input
// int s6 = 12;  //sensor 6 input

// int S1V = 0;  //sensor 1 data
// int S2V = 0;  //sensor 2 data
// int S3V = 0;  //sensor 3 data
// int S4V = 0;  //sensor 4 data
// int S5V = 0;  //sensor 5 data
// int S6V = 0;  //sensor 6 data

// void setup()
// {
//   Serial.begin(9600);
//   pinMode(s1, INPUT);
//   pinMode(s2, INPUT);
//   pinMode(s3, INPUT);
//   pinMode(s4, INPUT);
//   pinMode(s5, INPUT);
//   pinMode(s6, INPUT);

// }

// void loop() {
//   // low means no edge:: high means edge detected

//   S1V = digitalRead(s1);
//   S2V = digitalRead(s2);
//   S3V = digitalRead(s3);
//   S4V = digitalRead(s4);
//   S5V = digitalRead(s5);
//   S6V = digitalRead(s6);

//   //sensor1----------------------------
//   if (S1V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S1V == HIGH)
//   {
//     Serial.println("edge on 1");
//     delay(400);
//   }
//   //sensor2   -----------------------------

//   if (S2V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S2V == HIGH)
//   {
//     Serial.println("edge on 2");
//     delay(400);
//   }
//   //sensor3  ----------------------
//   if (S3V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S3V == HIGH)
//   {
//     Serial.println("edge on 3");
//     delay(400);
//   }
//   //sensor4----------------------------
//   if (S4V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S4V == HIGH)
//   {
//     Serial.println("edge on 4 ");
//     delay(400);
//   }
//   //sensor5 --------------------------------
//   if (S5V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S5V == HIGH)
//   {
//     Serial.println("edge on 5");
//     delay(400);
//   }
//   //sensor6 --------------------------------------------
//   if (S6V == LOW)
//   {
//     Serial.println("NO edge");
//     delay(400);
//   }
//   else if (S6V == HIGH)
//   {
//     Serial.println("edge on 6");
//     delay(400);
//   }

// }

// //void loop()
// //{
// //  SlV = digitalRead(sl);
// //  SrV = digitalRead(sr);
// //  if (SrV == LOW && SlV == LOW)
// //  {
// //    Serial.println("left");
// //    delay(1000);
// //  }
// //  if (SrV == HIGH && SlV == HIGH)
// //  {
// //    Serial.println("right");
// //    delay(1000);
// //  }
// //  if (SrV == LOW && SlV == HIGH)
// //  {
// //    Serial.println("DK");
// //    delay(1000);
// //  }
// //  if (SrV == HIGH && SlV == LOW)
// //  {
// //    Serial.println("KD");
// //    delay(1000);
// //  }
// //}
