# 🎮 Button Click Game

## 📌 Game Idea

This is a simple reaction-based Unity game where buttons spawn randomly on the screen.  
The player's goal is to click the buttons as fast as possible before they disappear.

The game becomes harder over time because buttons appear regularly and disappear after a short time.

---

## 🎮 Controls

- **Mouse Click / Tap**
  - Click on the buttons that appear on the screen

No keyboard controls are required.

---

## 🧠 Score System

- Every clicked button increases the score by **1 point**
- The score is displayed on the screen using **TextMeshPro UI**
- The score updates instantly after each successful click

---

## 🏆 Win Condition

- The player wins when reaching **10 points**
- When the win condition is met:
  - The game stops spawning new buttons
  - A **"YOU WIN!"** message appears on screen

---

## 💀 Lose Condition

- Each button has a limited lifetime (e.g. 3 seconds)
- If a button is NOT clicked before it disappears:
  - The game ends immediately
  - A **"GAME OVER!"** message appears on screen
  - No more buttons spawn

---

## 🤖 AI Usage

AI was used during development to:

- Generate Unity C# scripts for button spawning
- Implement click detection and score tracking
- Add win/lose conditions
- Fix bugs related to object lifetime and destruction
- Improve and simplify the code structure

The AI helped speed up development and provided working code examples for Unity UI systems.

---

## 🖼️ Screenshot

<img width="1063" height="605" alt="Screenshot" src="https://github.com/user-attachments/assets/f77819a7-fe2d-458e-8e66-a40a49c0343c" />


---

## 📂 Project Structure

- ButtonSpawner.cs → Main game logic
- UI Canvas → Score and Win/Lose messages
- Button Prefab → Clickable UI element

---

## ✅ Notes

- Built with Unity UI system
- Uses TextMeshPro for text rendering
- Designed as a simple reflex training game
