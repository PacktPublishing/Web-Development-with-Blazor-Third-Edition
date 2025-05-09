
<b><p align='center'>[![Packt Sale](https://static.packt-cdn.com/assets/images/humble+bundle/mega_bundle_dot_net_2.png)](https://www.humblebundle.com/books/c-and-net-mega-bundle-packt-books?view=tXxHRda-uIQk?utm_medium=affiliate)</p></b> 

# Web-Development-with-Blazor, Third-Edition
This is the code repository for [Web-Development-with-Blazor, Third Edition]( https://www.packtpub.com/product/web-development-with-blazor-third-edition/9781835465912), published by Packt.

**A practical guide to start building interactive UIs with C# 12 and .NET 8**

The author of this book is - Jimmy Engström
## About the book

Web Development with Blazor is your essential guide to building and deploying interactive web applications in C# – without relying on JavaScript.

Written by an early Blazor adopter and updated for .NET 8, this book takes you through the end-to-end development of an example app, helping you to overcome common challenges along the way. You’ll pick up both Blazor Server and Blazor WebAssembly and discover cutting-edge tools to enrich your development experience.

Responding to evolving needs, this edition introduces flexible hosting models, allowing you to mix and match hosting approaches to create flexible and scalable Blazor applications. It also presents the new Blazor templates, which provide ready-made solutions to simplify and expedite development. You'll learn about the game-changing server-side rendering (SSR), a hybrid hosting model blending the strengths of Blazor Server and Blazor WebAssembly, as well as streaming rendering, a new technique that boosts the performance and user experience of Blazor apps.

By the end of this book, you'll have the confidence you need to create and deploy production-ready Blazor applications using best practices, along with a big-picture view of the Blazor landscape.

## Key Takeaways
- Understand how and when to use Blazor Server, Blazor WebAssembly, and Blazor Hybrid
- Learn how to build simple and advanced Blazor components
- Explore how Minimal APIs work and build your own API
- Discover how to use streaming rendering and server-side rendering (SSR)
- Mix and match different hosting models to create flexible and scalable Blazor apps
- Familiarise yourself with the new Blazor templates that simplify development
- Debug your Blazor Server and Blazor WebAssembly applications

## Table of Contents
### Chapters
1. Hello Blazor 
2. Creating Your First Blazor App
3. Managing State – Part 1
4. Understanding Basic Blazor Components
5. Creating Advanced Blazor Components
6. Building Forms with Validation
7. Creating an API
8. Authentication and Authorization
9. Sharing Code and Resources
10. JavaScript Interop
11. Managing State – Part 2
12. Debugging the Code
13. Testing
14. Deploying to Production
15. Moving from, or Combining with, an Existing Site
16. Going Deeper into WebAssembly
17. Examining Source Generators
18. Visiting .NET MAUI
19. Where to Go from Here

## Outline and Chapter Summary
### Chapter 01, Hello Blazor 
The first chapter will explore where Blazor came from, what technologies made Blazor possible, and the different ways of running Blazor. We will also touch on which type (Blazor WebAssembly, Blazor Server, or Blazor Hybrid) is best for you.

### Chapter 02, Creating Your First Blazor App
In this chapter, we will set up our development environment so that we can start developing Blazor apps. We will create our first Blazor app and go through the project structure.
By the end of this chapter, you will have a working development environment and have created a Blazor App that can run a mix of streaming server-side rendering, Blazor Server, and Blazor WebAssembly.

### Chapter 03, Managing State – Part 1
In this chapter, we will start looking at managing state. There is also a continuation of this chapter in Chapter 11, Managing State – Part 2.
There are many different ways of managing state or persisting data. As soon as we leave a component, the state is gone. If we click the counter button and then navigate away, we don’t know how many times we’ll need to click the counter button and have to start over. You can’t imagine how many times I have clicked that counter button over the years. It is such a simple yet powerful demo of Blazor and was a part of Steve’s original demo back in 2017.
To get started quickly, I have split this chapter in two. In this chapter, we are focusing on data access, and we will come back to more state management in the second part.  Since this book focuses on Blazor, we will not explore how to connect to databases but create simple JSON storage instead.

### Chapter 04, Understanding Basic Blazor Components
In this chapter, we will look at the components that come with the Blazor template and start to build our own components. Knowing the different techniques used for creating Blazor websites will help us when we start building our components.
Blazor uses components for most things, so we will use the knowledge from this chapter throughout the book.

### Chapter 05, Creating Advanced Blazor Components
This chapter will focus on some of the features that will make our components reusable, which will enable us to save time and also give us an understanding of how to use reusable components made by others.
We will also look at some built-in components that will help you by adding additional functionality (compared to using HTML tags) when you build your Blazor app.

### Chapter 06, Building Forms with Validation
In this chapter, we will learn about creating forms and validating them, which is an excellent opportunity to build our admin interface where we can manage our blog posts and also take a look at the new Enhanced Form Navigation. We will also build multiple reusable components and learn about some of the new functionalities in Blazor.

### Chapter 07, Creating an API
When running Blazor using WebAssembly (InteractiveWebAssembly or InteractiveAuto) we need to be able to retrieve data and also change our data. For that to work, we need an API to access the data. In this chapter, we will create a web API using Minimal API.
When using Blazor Server, the API will be secured by the page (if we add an Authorize attribute), so we get that for free. But with WebAssembly, everything will be executed in the browser, so we need something that WebAssembly can communicate with to update the data on the server.

### Chapter 08, Authentication and Authorization
In this chapter, we will learn how to add authentication and authorization to our blog because we don’t want just anyone to be able to create or edit blog posts.
Covering authentication and authorization could take a whole book, so we will keep things simple here. This chapter aims to get the built-in authentication and authorization functionalities working, building on the already existing functionality that’s built into ASP.NET. That means that there is not a lot of Blazor magic involved here; many resources already exist that we can take advantage of.

### Chapter 09, Sharing Code and Resources
In this chapter, we will look at some of the things we already use when sharing components, and also at sharing CSS and other static files.
In this chapter, we will cover the following topics:
    •	Adding static files
    •	CSS isolation

### Chapter 10, JavaScript Interop
In this chapter, we will take a look at JavaScript. In specific scenarios, we still need to use JavaScript, or we will want to use an existing library that relies on JavaScript. Blazor uses JavaScript to update the Document Object Model (DOM), download files, and access local storage on the client.

### Chapter 11, Managing State – Part 2
In this chapter, we continue to look at managing state. Most applications manage state in some form.
A state is simply information that is persisted in some way. It can be data stored in a database, session states, or even something stored in a URL.
The user state is stored in memory either in the web browser or on the server. It contains the component hierarchy and the most recently rendered UI (render tree). It also contains the values or fields and properties in the component instances as well as the data stored in service instances in dependency injection.

### Chapter 12, Debugging the Code
In this chapter, we will take a look at debugging. The debugging experience of Blazor is a good one; hopefully, you haven’t gotten stuck earlier on in the book and had to jump to this chapter.
Debugging code is an excellent way to solve bugs, understand the workflow, or look at specific values. Blazor has three different ways to debug code, and we will look at each one.

### Chapter 13, Testing
In this chapter, we will take a look at testing. Writing tests for our projects will help us develop things rapidly.
We can run the tests to ensure we haven’t broken anything with the latest change, and also, we don’t have to invest our time in testing the components manually since it is all done by the tests. Testing will improve the quality of the product since we’ll know that things that worked earlier still function as they should.

### Chapter 14, Deploying to Production
In this chapter, we will take a look at the different options we have when deploying our Blazor application to production. Since there are many different options, going through them all would be a book all by itself.
We won’t go into detail, but rather cover the different things we need to think about so that we can deploy to any provider.
In the end, deploying is what we need to do to make use of what we build.

### Chapter 15, Moving from, or Combining with, an Existing Site
In this chapter, we will take a look at how we can combine different technologies and frameworks with Blazor.
What if we already have a site?
There are different options when it comes to moving from an existing site; the first question is, do we want to move from it, or do we want to combine it with the new technology?
Microsoft has a history of making it possible for technology to co-exist, and this is what this chapter is all about.

### Chapter 16, Going Deeper into WebAssembly
In this chapter, we will go deeper into technologies that are only relevant for Blazor WebAssembly.
Most things in Blazor can be applied to Blazor Server and Blazor WebAssembly. Still, since Blazor WebAssembly is running inside the web browser, we can do some things to optimize the code and use other libraries that we can’t use server side.
We will also look at some common problems and how to solve them.

### Chapter 17, Examining Source Generators
In this chapter, we will look at writing code that generates code. Even though this chapter isn’t directly related to Blazor development, it still has a connection to Blazor, as we’ll discover.
The subject of source generators is a book on its own, but I wanted to introduce it since they are used by Blazor and, honestly, it is one of my favorite features.

### Chapter 18, Visiting .NET MAUI
So far, we have talked about Blazor WebAssembly and Blazor Server, but what about the third option?
In this chapter, we will visit .NET MAUI, Microsoft’s new cross-platform development platform.
This chapter will not be a deep dive into .NET MAUI, since that can be a book all in itself.

### Chapter 19, Where to Go from Here
The book is coming to an end, and I want to leave you with some of the things we have encountered while running Blazor in production ever since it was in preview. We will also talk about where to go from here.
In this chapter, we will cover the following topics:
   •	Learnings from running Blazor in production
   •	The next steps


> If you feel this book is for you, get your [copy](https://www.amazon.in/Web-Development-Blazor-practical-interactive-ebook/dp/B0CW16SQC2) today! <img alt="Coding" height="15" width="35"  src="https://media.tenor.com/ex_HDD_k5P8AAAAi/habbo-habbohotel.gif">

### Following is what you need for this book: ###
This book is for .NET web developers and software developers who want to use their existing C# skills to build interactive SPA applications running either inside the web browser using Blazor WebAssembly, or on the server using Blazor Server.

You’ll need intermediate-level web-development skills, basic knowledge of C#, and prior exposure to .NET web development before you get started; the book will guide you through the rest.

With the following software and hardware list you can run all code files present in the book.

## Software and Hardware List

| Software covered in this book  | OS requirements    |
| :---: | :---: |
| Visual Studio 2022, .NET8  |  Windows 10 or later, macOS, Linux  |

## Know more on the Discord server <img alt="Coding" height="25" width="32"  src="https://cliply.co/wp-content/uploads/2021/08/372108630_DISCORD_LOGO_400.gif">

You can get more engaged on the discord server for more latest updates and discussions in the community at [https://packt.link/WebDevBlazor3e](https://packt.link/WebDevBlazor3e) 

## Download a free PDF <img alt="Coding" height="25" width="40" src="https://emergency.com.au/wp-content/uploads/2021/03/free.gif">

_If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost. Simply click on the link to claim your free PDF._
[https://packt.link/free-ebook/9781835465912](https://packt.link/free-ebook/9781835465912) <img alt="Coding" height="15" width="35"  src="https://media.tenor.com/ex_HDD_k5P8AAAAi/habbo-habbohotel.gif">

We also provide a PDF file that has color images of the screenshots/diagrams used in this book at "https://packt.link/gbp/9781835465912" <img alt="Coding" height="15" width="35"  src="https://media.tenor.com/ex_HDD_k5P8AAAAi/habbo-habbohotel.gif">

## Get to Know the Author

Jimmy Engström has been developing ever since he was 7 years old and got his first computer. He loves to be on the cutting edge of technology, trying new things. When he got wind of Blazor, he immediately realized the potential and adopted it already when it was in beta. He has been running Blazor in production since it was launched by Microsoft.

His passion for the .NET industry and community has taken him around the world, speaking about development. Microsoft has recognized this passion by awarding him the Microsoft Most Valuable Professional award 10 years in a row.
