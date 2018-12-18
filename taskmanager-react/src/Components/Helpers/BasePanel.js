import React, { Component } from "react";
import { Panel } from "react-bootstrap";

class BasePanel extends Component {
  render() {
    return (
      <div>
        <Panel bsStyle="primary">
          <Panel.Heading>
            <Panel.Title componentClass="h3">
              {this.props.item.name}
            </Panel.Title>
          </Panel.Heading>
          <Panel.Body>{this.props.item.description}</Panel.Body>
        </Panel>
      </div>
    );
  }
}

export default BasePanel;
