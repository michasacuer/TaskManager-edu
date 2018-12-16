import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import ProjectDetails from "./ProjectDetails";

class Project extends Component {
  state = {
    showDetails: false
  };
  constructor(props) {
    super(props);
    this.state = {
      showDetails: false
    };
  }

  toggleShowProjects = () => {
    this.setState(prevState => ({
      showDetails: !prevState.showDetails
    }));
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem>{this.props.project.name}</ListGroupItem>
        <Button onClick={this.toggleShowProjects} bsStyle="primary">
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
