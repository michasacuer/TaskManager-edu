import React, { Component } from "react";
import { Panel } from "react-bootstrap";

const basepanel = props => {
  return (
    <div>
      <Panel bsStyle="primary">
        <Panel.Heading>
          <Panel.Title componentClass="h3">{props.item.name}</Panel.Title>
        </Panel.Heading>
        <Panel.Body>{props.item.description}</Panel.Body>
      </Panel>
    </div>
  );
};

export default basepanel;
