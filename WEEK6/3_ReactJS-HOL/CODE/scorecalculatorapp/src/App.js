// src/App.js
import React from 'react';
import StudentDetailsCard from './Components/StudentDetailsCard';
import './App.css'; // Or directly include minimal body styles in mystyle.css

function App() {
  // You might want to calculate the score here if it's dynamic
  const total = 284;
  const goal = 300; // Assuming a goal to calculate percentage
  const calculatedScore = ((total / goal) * 100).toFixed(2); // Calculate to 2 decimal places

  return (
    <div className="App">
      <StudentDetailsCard
        name="Steeve"
        school="DNV Public School"
        totalMarks={total}
        scorePercentage={calculatedScore}
      />
    </div>
  );
}

export default App;