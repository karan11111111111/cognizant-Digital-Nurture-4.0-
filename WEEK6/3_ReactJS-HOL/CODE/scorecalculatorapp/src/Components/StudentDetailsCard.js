// src/Components/StudentDetailsCard.js
import React from 'react';
import PropTypes from 'prop-types'; // Still good practice to keep
import './../Stylesheets/mystyle.css';

const StudentDetailsCard = ({ name, school, totalMarks, scorePercentage }) => {
  return (
    <div className="student-details-container">
      <h1 className="student-details-heading">Student Details:</h1>
      <div className="detail-line">
        <span className="detail-label">Name: </span>
        <span className="name-value">{name}</span>
      </div>
      <div className="detail-line">
        <span className="detail-label">School: </span>
        <span className="school-value">{school}</span>
      </div>
      <div className="detail-line">
        <span className="detail-label">Total: </span>
        <span className="total-value">{totalMarks}Marks</span> {/* "Marks" concatenated as in image */}
      </div>
      <div className="detail-line">
        <span className="detail-label">Score: </span>
        <span className="score-value">{scorePercentage}%</span> {/* "%" concatenated as in image */}
      </div>
    </div>
  );
};

// PropTypes for validation
StudentDetailsCard.propTypes = {
  name: PropTypes.string.isRequired,
  school: PropTypes.string.isRequired,
  totalMarks: PropTypes.number.isRequired,
  scorePercentage: PropTypes.string.isRequired, // Changed to string as it's formatted in the image
};

export default StudentDetailsCard;