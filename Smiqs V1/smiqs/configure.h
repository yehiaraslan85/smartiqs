#define DEBUG       1   // set to 1 to enable debug traces

#define USE_DISPLAY 0   // set to 1 if you want to use an LCD display
                        // when USE_DISPLAY=0, debug traces are written to Serial

#define USE_NTP     0   // set to 1 to use NTP for setting local time, 
                        // if USE_NTP=0, the device will get time info from cellular network

#define X509        0   // else auth will be using SYMKEY
#define ARM_PELION  0  
//#define IOTC_SINGLE_ENROLLMENT
#define IOTC_GROUP_ENROLLEMENT

// Azure IoT Central device information
static char PROGMEM iotc_enrollmentKey[] = "Y8zAzJ80rRbVG7PmCd/qy2762X1aljkxkZgYlxkQhJGVXGUKDnvXCG027mKVbyRd+ZskfqCivXxk7+N7+MiFPQ==";//SharedAccessSignature sr=e779b45b-ae87-4104-b486-d3a968644e7a&sig=r%2Fkv3vE2eLVDpzPcJ2ssbNj8ToaHC2Qz8JkIGM82j2U%3D&skn=GroupKey&se=1620933659821";
static char PROGMEM iotc_scopeId[] = "0ne000ACF86";

// GSM information
static char PROGMEM PINNUMBER[]     = "1985";
// APN data
static char PROGMEM GPRS_APN[]      = "internet1";
static char PROGMEM GPRS_LOGIN[]    = "";
static char PROGMEM GPRS_PASSWORD[] = "";

// **** DEVICE PROPERTIES ****
#define DEVICE_PROP_FW_VERSION          "1.0.0-20190704"
#define DEVICE_PROP_MANUFACTURER        "Arduino"
#define DEVICE_PROP_PROC_MANUFACTURER   "Microchip"
#define DEVICE_PROP_PROC_TYPE           "SAMD21"
#define DEVICE_PROP_DEVICE_MODEL        "MKR1400 GSM"
// ***************************

int pinDHT = 2;
int Valve_Controller = 3;
#define dataPin  0
#define clockPin 1
float pulseVoltage = 0.5;
float calibrationFactor =  7.5;
int SolenoidValve_valSensorMax = 60;
int SolenoidValve_valSensorMin = 48;
int NumberOfValves=1;
int deviceMode = 1;
char* MobileNumber = "0555103640";
String MobNumber = "0555103640";
