import React from 'react';
import styles from './CohortDetails.module.css';

const CohortDetails = ({ cohort }) => {
  const titleClassName = cohort.titleColor === 'blue' ? styles.blueText : styles.greenText;
  const statusClassName = styles.statusText; // All status text appears green in the image

  return (
    <div className={styles.box}>
      <h3 className={titleClassName}>{cohort.id}</h3>
      <dl>
        <dt>Started On</dt>
        <dd>{cohort.startedOn}</dd>
        <dt>Current Status</dt>
        <dd className={statusClassName}>{cohort.currentStatus}</dd>
        <dt>Coach</dt>
        <dd>{cohort.coach}</dd>
        <dt>Trainer</dt>
        <dd>{cohort.trainer}</dd>
      </dl>
    </div>
  );
};

export default CohortDetails;
