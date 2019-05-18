# Instinctual Learning and Instinctual Reinforcement Learning

*I want to introduce this technical series of blog posts that outline a concept I have been working on for some time. Currently, I refer to this concept as Instinctual and Instinctual Reinforcement Learning. This concept crosses many areas of machine learning from evolutionary algorithms, gene expression programming to deep learning and reinforcement learning. It is therefore not intended for novices or layman, as many of my other blog posts are.*

[Source code for this article.](https://github.com/cxbxmxcx/InstinctualLearning)

## **Instinctual Learning**

The motivation behind Instinctual Learning is the search for the functions that simulate lower forms of learning we will refer to as instincts. An instinct is defined as the patterns or behavior in an organism in response to some stimuli. For lower level instincts this behavior is learned over generations of species and becomes an embedded system within the organism. Take for example the Pacific North West Salmon. A salmon will instinctively swim to it’s original spawning grounds given no previous instructions. We will assume the knowledge is not passed on to other salmon through communication. Meaning the organism itself needs to learn to return home across generations by some form of genetic learning.

![](https://cdn-images-1.medium.com/max/2304/1*cz7qe67GKJw59aIZoHxDDQ.png)

## Instinctual Reinforcement Learning

Instincts describe a base form of learning which we could account for several different forms. One form of learning we often associate with feedback is called Reinforcement Learning. It is further suggested that RL is just an advanced form of Instinctual Learning but with the introduction of feedback or rewards. With that in mind it is best to think of Instinctual Learning as a meta learning or auto machine learning solution. Since the RL portion, or the part that introduces rewards or feedback is an advanced form it will be looked at in the next blog entry.

## Base Form of Learning

In order to simulate Instinctual Learning we therefore need a mathematical system of equations that define the actions of the organism. If we take some inspiration from RL here we can derive or define the following:

![](https://cdn-images-1.medium.com/max/2000/1*w8b5qq42xU1ADUmSMrvcnQ.png)

![](https://cdn-images-1.medium.com/max/2000/1*ZyHPKPBz0r_t9lK6wII9lw.png)

What we define here is 2 unknown equations. One that defines the action of the organism and the other that updates the memory. If we put this in terms of a deep learning network. The action represents the forward pass and the memory update represents the training or in case of neural networks, backpropagation. The following diagram is intended to describe this concept further:

![](https://cdn-images-1.medium.com/max/2468/1*uuQaNfrXorelZLRB9MqChA.png)

Solving for the equations themselves is best suited to evolutionary or what is often groups as genetic algorithms. One class of such algorithms best suited to finding specific equations using machine learning is called Gene Expression Programming (GEP). GEP was developed by Candida Ferreira in 2001 and is derived from the family of machine learning algorithms derived from evolutionary theory and are associated with evolutionary computation.

![Candid Ferriera and GEP: src GEPSOFT](https://cdn-images-1.medium.com/max/2000/1*3zuQMtraHX2I62Oo0opbWQ.png)*Candid Ferriera and GEP: src GEPSOFT*

## Gene Expression Programming

GEP defines a method or search pattern that allows us to use evolutionary patterns to derive our unknown equations. The basic form is used to derive relatively simple equations but GEP can be used to derive code (expression trees) and handle more complex data structures. An example of how the process works is summarized in the diagram below:

![Source: Candida Ferriera](https://cdn-images-1.medium.com/max/2000/0*ZrreaPxXbp_FsH-_.gif)*Source: Candida Ferriera*

For the purposes of this post we will use single quantity values. GEP has been extended to include tensors and it is the goal of this series to later also introduce tensor mathematics as a way to first solve regression problems. Then the ultimate goal will be to create an Instinctual Reinforcement Learner that can learn to learn to classify the handwritten MNIST digits database. It will be left up to the reader to further their knowledge on Genetic Programming and GEP. A great starting point is the Gepsoft site itself which offers a free trial version of software that can allow you to explore GEP on your own.
[**Gepsoft GeneXproTools - Data Modeling & Analysis Software**
*GeneXproTools 5.0 is an easy to use modeling and data mining software for data analysis.*www.gepsoft.com](https://www.gepsoft.com/)

*The Gepsoft tool is a fun tool to explore and I myself have used it to solve the odd classification and regression problem when no other solution would fit well. If you have a strong background in data science and not explored GEP before you may also be pleasantly surprised in other ways.*

## The Problem

In order to simulate an instinctual learner we are going to use a grid world like environment with the goal of the agent/organism to make it to the highest point. Below is a diagram of how this looks:

![Grid world environment](https://cdn-images-1.medium.com/max/2000/1*QUFAXpC-qYrBHDfDTAY2Cg.png)*Grid world environment*

Furthermore, in this environment we denote the state or the cell the organism is currently in by the corresponding number (1–16). The organism will always start at position 1 with it’s ultimate goal of reaching position 16. The organism can move up (1), right (2), down (3) and left (4) when not blocked by a wall. The red arrows denote examples of where the organism is unable to move because of blocking wall.

If we consider our earlier salmon analogy. The salmon needs to find it’s way home given some internal system of equations. We will use GEP to find the equations but in order to do that we need to define some reward or fitness for organism/algorithm. In order to simplify this model we assume all rewards are awarded at the end of an episode. Which in turn means that our reward function could also be thought of as a fitness function. The final fitness for our algorithm will be set by what state it is able to attain. Higher states provide greater rewards or fitness and the reward value is denoted by the lower right number. For 16, the goal state, this value is 1.0. We set the other rewards based on how far the organism progresses but at the same time we will also introduce a negative step reward accumulated for each step taken. Introducing a step reward encourages the agent to be more efficient and is a trick borrowed from RL.

## Solving the Problem

In order to solve this problem with GEP we are going to use a C# package called [GeneticSharp](https://github.com/giacomelli/GeneticSharp). [GeneticSharp](https://github.com/giacomelli/GeneticSharp) is an advanced genetic programming package that provides a mechanism for playing with gene expression programming among other evolutionary programming concepts.

*Unfortunately, I was unable to find a comparable library in Python that was as easy to use or as powerful. If you are aware of any GEP tools in Python that support tensors or TensorFlow please leave a comment at the end.*

I have a working code example up on GitHub at:
[**cxbxmxcx/InstinctualLearning**
*Contribute to cxbxmxcx/InstinctualLearning development by creating an account on GitHub.*github.com](https://github.com/cxbxmxcx/InstinctualLearning)

*Feel free to pull down the code as I will refer to it several times over the remainder of the post.*

The example source code consists of 2 projects. One class library and the other a console app for testing. The **InstinctualLearning.Console** project contains the main code for loading the various setup code from **GeneticSharp** and is common across evolutionary computation. This example borrows from the GenticSharp examples in how it is setup and operated.

## The Code

The easiest way for me to describe the rest of the process to a more general audience is with the code. You can open the source in Visual Studio Code, Community or Professional and review each of the sections as I summarize them below. You can run the source code by loading the solution and setting the console project as the startup. From there just launch the program and a console window will open. For the purposes of later comparisons I have kept the standard GEP interface. That means the program is expecting sets of inputs to equal some value. The secret here is that program only currently requires one set to define the number of inputs. All this means is that you just needs to fill out the input given the example in the image below:

![Running the Code](https://cdn-images-1.medium.com/max/2000/1*bsgx3GSSd1EgDtv-Q_lbTA.png)*Running the Code*

In order to run the code you just need to enter:

**1,2,3=6** *or any combination of 3 inputs equally one output*

**GA** *this starts the next step*

**6** *this is the number of operations total for our expression, GEP provides a mechanism to minimize this number as needed. The minimum number of parameters to solve this problem are 6. The larger the number of parameters the larger the functions search space.*

As the console app runs, the output will change and you will see the inputs, max operations and combined function. After this follows the current best path the organism has found, examples below:

![](https://cdn-images-1.medium.com/max/2000/1*FnnyHe0Npp86qDUeDyz6vA.png)

The function represents the combined function. Recall that we want to derive a set of functions. One to determine actions and the other to update memory. We allow for this by simply dividing the function our GEP finds for us into 2 parts, action and memory. Therefore, the function shown actually needs to be split in half. In order to understand this further we will look at the code that defines the organism fitness below:

![](https://cdn-images-1.medium.com/max/2000/1*i1eG7gmqznwGUQOMNfswtw.png)

Evaluate is the function by where all the work happens. It’s purpose is to take a new organism provided by the GEP system and evaluate it’s fitness or total reward. We could also use the term cumulative reward here as well. After some basic initialization of parameters we see the function getting equally divided in the following block of code:

![extracting the action and memory functions](https://cdn-images-1.medium.com/max/2000/1*I51xwf88IC2lBVNUBjaRAw.png)*extracting the action and memory functions*

Recall that the action and memory functions define our organisms instinctive learning system. In our particular example we don’t use external inputs. Rather the inputs for those functions will be defined as the organism moves through it’s environment. If you look down further in the code you can see the loop that cycles through the episodes. This is our training loop and at each step in the training loop the organism inputs the state, action and memory. Then is uses the action function to calculate it’s next action. It then inputs the action and updates it’s memory by executing the memory function. The specific code to do this is shown below:

![](https://cdn-images-1.medium.com/max/2000/1*AWi9-DWZcnTCZpe0KM43yg.png)

Again, at this point we omit any concept of feedback or immediate rewards to keep things simpler. The environment in the current example is the Grid World environment previously outlined but adding other environments should be fairly simple. The code for the Grid World environment is fairly simple and should be self explanatory for anyone who has read this far.

For each iteration of an episode, the organism receives the current state, denoted by it’s current cell. It then uses the action part of the equation to derive its next action. Then the organism acts on that action and updates its memory accordingly with the memory function. When you run the example you will see the organism’s path get generated. The path shows which cells the organism followed and the actions it took to get there. Below is another example running showing the results in more detail:

![](https://cdn-images-1.medium.com/max/2000/1*tHPwE1nosjow5r8qJZzvdA.png)

## Generalized Equations

The example output shows one possible set of optimum equations that can be derived to solve the Grid World problem. Of all the optimum solutions derived none were observed to include the state parameter in the derived function. This seemed somewhat counter intuitive. Another interesting side effect is the fact that by not using state in the derived equations are general enough to apply to any size Grid World, be it size 16, 100 or 1000. This may mean, this method could provide more general solutions for all manner of learning problems.

## Next Steps

Instinctual Learning is intended to define a base system of learning in which higher levels of learning such as feedback or reinforcement learning may be derived. This is what I hope to cover in my next series of blogs about this topic, albeit please don’t expect these to come out in quick succession:

**1 — Instinctual Learning** — this blog describing the premise of Instinctual Learning and how an organism may solve the a common Grid World problem.

**2 — Instinctual Reinforcement Learning **— in the next blog I will introduce the feedback into the learning system and see how an organism/agent may use this to solve the typical contextual bandit/room.

**3 — Instinctual Learning with Tensors** — one of the main limitations with GEP is the way it handles feature inputs. This has shown to be corrected by treating parameters as multidimensional tensors. My intention here will be to introduce TensorFlow and thus not just create expression trees but rather TF graphs. Introducing tensors will allow for any input of state, action, memory and rewards to be calculated in the system. The ultimate goal of this stage will be to develop an organism that can learn to perform linear regression.

**4 — Instinctual Reinforcement Learning with Tensors **— the current final end goal is to develop a system that can learn to recognize the MNIST hand written digits with a better than random chance in about 100–1000 iterations. The purpose of this step is to prove how well the agent can be derived to learn and recognize digits. It is expected that resulting derived equations may share some insight into deep learning and the fundamentals of neural networks.

**0 — Gene Expression Programming **— I have chosen to omit the explanation GEP in this blog in order to keep this post under 10 minutes. If there is enough interest I can certainly provide blog on a tutorial for doing GEP.

## **Conclusion**

The introduction of Instinctual Learning is intended as a means and explanation for how learning itself was derived or evolved. In this post we explored the foundations or base instincts an organism could use to evolve a learning solution. This solution is based on two fundamental equations or functions that define the action and then the equations that updates the memory. A method not unlike how a deep learning system behaves. With the action representing the forward pass through the network and the memory or update function as a form of backpropagation of errors. It is hoped that by introducing tensors into this system we can explore further foundations of deep learning and other machine learning systems.

*Future blog posts may or may not use Python. Please post a comment if you know of GEP system for Python that does or may accommodate TensorFlow?*
