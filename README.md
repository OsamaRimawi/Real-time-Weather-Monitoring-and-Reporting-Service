## **General Description:**

a C# console application that simulates a real-time weather monitoring and reporting service. The system is capable of receiving and processing raw weather data in multiple formats (JSON, XML, etc.) from various weather stations for different locations. The application includes different types of 'weather bots' each of which is configured to behave differently based on the weather updates it receives.

## **Supported Input Formats:**

### **JSON Format**:

```json

{
  "Location": "City Name",
  "Temperature": 23.0,
  "Humidity": 85.0
}
```

### **XML Format**:

```xml
<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>
```

The system allows for the addition of new data formats with minimal changes to the existing code, demonstrating the Open-Closed principle of SOLID design principles.

## **Different Bot Types:**

1. **RainBot**: This bot gets activated when the humidity level exceeds a certain limit specified in its configuration. Upon activation, it performs a specific action that involves printing a pre-configured message.
2. **SunBot**: This bot gets activated when the temperature rises above a certain limit specified in its configuration. Upon activation, it performs a specific action that involves printing a pre-configured message.
3. **SnowBot**: This bot is activated when the temperature drops below a certain limit specified in its configuration. Upon activation, it performs a specific action that involves printing a pre-configured message.

## **Example of How to Interact with the Application:**

The user starts the application and chooses **`Load weather data:`**.

User enters the name of the file that is in JSON format: **`{"Location": "City Name", "Temperature": 32, "Humidity": 40}`** or XML format: **`<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>`**

The system responds by activating the bots according to the provided weather data and the bots' configurations. If SunBot is enabled and its temperature threshold is lower than the given temperature, the system may respond with:

```vbnet
SunBot activated!
SunBot: "Wow, it's a scorcher out there!"
```

### **Configuration Details:**

All the bot's settings are controlled via a configuration file, including whether it is enabled, the threshold that activates it, and the message it outputs when activated. The configuration file should be in a JSON format. Here is an example:

```json
{
  "RainBot": {
    "enabled": true,
    "humidityThreshold": 70,
    "message": "It looks like it's about to pour down!"
  },
  "SunBot": {
    "enabled": true,
    "temperatureThreshold": 30,
    "message": "Wow, it's a scorcher out there!"
  },
  "SnowBot": {
    "enabled": false,
    "temperatureThreshold": 0,
    "message": "Brrr, it's getting chilly!"
  }
}

```

In this example, the **`enabled`** property turns the bot on or off, the **`humidityThreshold`** or **`temperatureThreshold`** sets the limit that will activate the bot, and **`message`** is what the bot will output when it is activated.

the program reads this configuration file at the start of the application and adjusts the behavior of the bots according to the given settings.

## **Additional Notes:**

The Observer and Strategy design patterns, handling file input/output operations, and data manipulation for multiple formats (JSON, XML) all were tackled during the design of this service. The application is designed in such a way that adding new types of bots or weather data formats should not require significant changes to the existing code.
