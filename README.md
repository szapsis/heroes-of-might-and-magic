# Heroes of Might and Magic

A C# console game inspired by the Heroes of Might and Magic series.

The project is being developed as a learning exercise to explore object-oriented programming, game architecture, Git, Docker, and local AI integration using Ollama.

---

## Features

- Turn-based battle simulation
- Creature stacks with total health
- Random damage generation
- Faction-based unit structure
- Object-oriented design and inheritance
- AI-generated battlefield descriptions using Ollama
- Local AI integration through the Ollama HTTP API
- .NET 10
- Docker support

---

## Architecture

```text
Heroes_of_Might_and_Magic
│
├── AI
│   └── Narrator.cs
│
├── Models
│   ├── Unit.cs
│   └── Units
│       ├── Castle
│       └── Necropolis
│
├── Program.cs
└── Battle.cs
```

---

## Requirements

- .NET 10 SDK
- Ollama
- A locally installed Ollama model
- Docker (optional)

---

## Ollama Setup

Make sure Ollama is running locally.

The default AI model is:

```text
qwen2.5:1.5b
```

Install the model:

```bash
ollama pull qwen2.5:1.5b
```

Check installed models:

```bash
ollama list
```

By default, Ollama must be available at:

```text
http://localhost:11434
```

Before each battle, the game sends information about the participating armies to Ollama. The model generates a short atmospheric description of the battlefield.

The AI is used only for narrative content. All combat mechanics—including damage calculation, health management, victory conditions, and game rules—are implemented entirely in C#.

---

## Run

```bash
dotnet run
```

---

## Run with Docker

Build the image:

```bash
docker build -t heroes-game .
```

Run the container:

```bash
docker run -it --rm heroes-game
```

> **Note**
>
> When running inside Docker, `localhost` refers to the container itself.
> If Ollama is running on the host machine, additional networking configuration is required.

---

## Roadmap

- [x] Unit model
- [x] Creature stacks
- [x] Random damage generation
- [x] Battle simulation
- [x] Faction-based unit structure
- [x] Unit inheritance
- [x] AI battlefield narration
- [ ] Attack and Defense modifiers
- [ ] Creature losses
- [ ] Hero system
- [ ] Army management
- [ ] Battlefield grid
- [ ] Magic system
- [ ] Artifacts
- [ ] Save and load game
- [ ] Campaign mode

---

## Technologies

- C#
- .NET 10
- Object-Oriented Programming (OOP)
- Ollama
- HTTP API
- Async/Await
- Git
- Docker

---

## Project Status

This project is under active development and serves as a learning project focused on:

- C# programming
- Object-oriented design
- Game development
- AI integration
- Software architecture
- Version control with Git
- Containerization with Docker