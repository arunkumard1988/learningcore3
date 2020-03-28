@@ -0,0 +1,88 @@
# Project Title

Car Booking Application with Oneway,RoundTrip , MultiCity and Package Option.

### Project Description

We have implemented oneway trip part in this application. Source is fixed as Bangalore and destination is implemented using Google Map api.
Trial account created and api is used. Based upon selected destination Km (from source - Bangalore) is calculated via Google Distance Matrix Api. Using Three driver details (price per km) the final pricing is calculated and listed in the landing page. Once user selectes the driver we redirect the user to capture his information and pickup time. From there we redirect the user to Payment Gateway (PayuMoney). We have used sandbox api for testing purpose. Once we receive the payment response we redirect the user to Booking Confirmation Page.


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

Visual Studio 2019 - Dot net core 3.0

Docker - Windows 10 

Google API Key - For Maps

Payu Payment Gateway - Salt Key & Merchant Key
 

### Installing

A step by step series of examples that tell you how to get a development env running.

Load insta3core3.sln in Visual studio and build the project. Run Unit tests and run the application.

## Running the tests

Unti Test Coding is written with basic conditions. We can increase the level of conditions if required.


## Deployment

All services are dockerized and docker image of this application is present in Docker Hub
https://hub.docker.com/repository/docker/arunkumard1988/insta3core3

## Author

* **Arun Kumar D** 
