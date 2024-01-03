<p align="center">
  <img src="https://github.com/navpreet032/ChromaKeys/assets/55250212/cc921c98-5cfe-4f3b-9ee1-ee90c7b08993" alt="Your Image Description">
</p>
<p align="center">
  <h1 align="center">ChromaKeys</h1>
</p>

Welcome to ChromaKeys, an innovative solution designed to bring dynamic control over RGB keyboard lighting directly to your fingertips. Our API bridges the gap between hardware capabilities and software flexibility, offering an unparalleled level of customization for your typing experience.

## What is ChromaKeys?

ChromaKeys is an API-first platform that empowers users to manipulate the RGB lighting of their keyboards with ease and precision. Whether you're looking to set a mood, enhance your gaming setup, or receive visual feedback from your development environment, ChromaKeys provides the tools to make it happen.
Features

  - Static Light Control: Set a static color across your keyboard with simple API calls, perfect for creating a consistent aesthetic or reducing distractions.
  - *Dynamic Pattern Creation: Craft and store unique lighting patterns that can be triggered by specific events or user interactions.
  - Event-Based Lighting: Integrate with software like IDEs to reflect system states—imagine your keyboard flashing green upon successful code compilation or turning red to indicate errors.
  - Multi-Client Handling: Designed with concurrency in mind, ChromaKeys can handle multiple requests from different clients, ensuring a responsive experience across the board.

## How It Works

ChromaKeys utilizes a robust API that communicates with your keyboard's RGB lighting system. By sending specific commands through the API, you can instantly change lighting patterns, colors, and effects. The API is built to be intuitive and developer-friendly, making it easy to integrate with existing software or to be used standalone for customizing your workspace.
### Running the Server:
Clone the repo and open it in Visual Studio and run the project. The server will start on localhost `5000`.

## API endpoints:
- ### api/patterns/set_static_color:
    Set the Static Color of whole Keyboard
  ![image](https://github.com/navpreet032/ChromaKeys/assets/55250212/6c611f70-d94d-4a8b-ba3f-9317cab22b75)

- ### api/patterns/set_pattern:
    Add's new pattern sequance.
  ![image](https://github.com/navpreet032/ChromaKeys/assets/55250212/82e99c33-1f7c-4446-a20c-29c9f6703b89)
    
- ### api/patterns/play_notification:
    Plays the Pattern based on the `Pattern name`.
  ![image](https://github.com/navpreet032/ChromaKeys/assets/55250212/9c1e06aa-3d8a-4809-87c8-8542e385f0de)

## Data Sequance for Patterns 
Visualize keyboard zones as frames in an animation sequence. Crafting a compelling animation requires careful design of each frame to ensure fluid motion. ChromaKeys iterates over each zone to bring your customized patterns to life. Here's how you can structure the data to create your desired effect:
  - Zone: Identify the specific zone of the keyboard you wish to modify.
  - RGB Values: Specify the red, green, and blue color values to set the desired color for the selected zone.
  - States: Define an array of boolean values representing the active (on) or inactive (off) state for each zone; true indicates the zone is active, while false indicates it is inactive.
  - Speed: Set the delay, in milliseconds, to control the transition speed between iterations.
  - IsStatic: A boolean value where true sets the zone state before the color, and false implies color will be set before the zone state. This determines the precedence of color or state setting in the animation flow.
Example:
  
```JSON
[
{ "zone": 1, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 50, "isStatic": true },
{"zone": 2, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 50, "isStatic": true},
{"zone": 3, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 50, "isStatic": true},
{"zone": 4, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 50, "isStatic": true},
{"zone": 4, "r": 255, "g": 0, "b": 0, "states": [false,false,false,false], "speed": 150, "isStatic": true},
{"zone": 4, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 150, "isStatic": true},
{"zone": 4, "r": 255, "g": 0, "b": 0, "states": [false,false,false,false], "speed": 150, "isStatic": true},
{"zone": 4, "r": 255, "g": 0, "b": 0, "states": [true, true, true, true], "speed": 150, "isStatic": true}
]
```

 *: feature in development