# WPF-LandmarkAI
Basic WPF Landmark AI app that recognize images selected by the user.
***

## Table of contents
- [GUI](#gui)
  - [Main](#main)
  - [Recognizing images](#recognizing-images)
- [Main features](#main-features)
- [Setup of the project](#setup-of-the-project)
- [Technologies](#technologies)
- [Author](#author)
***

## GUI
### Main 
![](/Screenshots/Main.png)

### Recognizing images
![](/Screenshots/RecognizingImages.png)
***

## Main features
This app let the user to:
* select an image and recognize it
***

## Setup of the project
To succesfully use this project as base of your personal project, you have to follow this steps to correctly create the Custom Vision project.
1) Go to https://www.customvision.ai/ site and register your profile
2) Define a new project (to do this you have to create your Azure account) and publish it
3) Add images to the project and for each of them define a tag
4) Train the AI
5) Under "Performance" tab click on "Prediction URL" so copy this parameters in the method MakePredictionAsync variables to set up the rest api properties
***

## Technologies
A list of technologies used within the project:
* C#
* Visual Studio 2022
* WPF
* .NET 6
* Custom Vision
***

## Author
- GitHub - [@totarochristian](https://github.com/totarochristian)
- Frontend Mentor - [@totarochristian](https://www.frontendmentor.io/profile/totarochristian)
- Linkedin [Christian Totaro](https://www.linkedin.com/in/christian-totaro-080a7018a/)
***