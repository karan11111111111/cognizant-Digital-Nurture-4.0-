import React from 'react';
import CohortDetails from './CohortDetails';
import './App.css'; // Assuming you might have some global app styles

function App() {
  const cohorts = [
    {
      id: "INTADMDF10 -.NET FSD",
      startedOn: "22-Feb-2022",
      currentStatus: "Scheduled",
      coach: "Aathma",
      trainer: "Jojo Jose",
      titleColor: "blue"
    },
    {
      id: "ADM21JF014 -Java FSD",
      startedOn: "10-Sep-2021",
      currentStatus: "Ongoing",
      coach: "Apoorv",
      trainer: "Elisa Smith",
      titleColor: "green"
    },
    {
      id: "CDBJF21025 -Java FSD",
      startedOn: "24-Dec-2021",
      currentStatus: "Ongoing",
      coach: "Aathma",
      trainer: "John Doe",
      titleColor: "green"
    }
  ];

  return (
    <div className="App p-4">
      <h1 className="text-3xl font-bold mb-6 text-center">Cohorts Details</h1>
      <div className="flex flex-wrap justify-center">
        {cohorts.map((cohort, index) => (
          <CohortDetails key={index} cohort={cohort} />
        ))}
      </div>
    </div>
  );
}

export default App;