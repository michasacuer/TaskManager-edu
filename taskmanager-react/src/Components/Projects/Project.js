import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import ProjectDetails from "./ProjectDetails";
import { Link } from "react-router-dom";

class Project extends Component {
  constructor(props) {
    super(props);
    this.state = {
      showDetails: false
    };
  }
  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem>{this.props.project.name}</ListGroupItem>
        <Button
          onClick={() => this.setState({ showDetails: true })}
          bsStyle="primary"
        >
          Details
        </Button>
        {this.state.showDetails && (
          <ProjectDetails project={this.props.project} />
        )}
      </ButtonToolbar>
    );
  }
}

export default Project;
