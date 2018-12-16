import React, { Component } from "react";
import Project from "./Project";
import { ListGroup } from "react-bootstrap";

class ProjectsList extends Component {
  render() {
    return (
      <ListGroup>
        {this.props.projects.map(project => {
          return <Project project={project} key={project.id} />;
        })}
      </ListGroup>
    );
  }
}

export default ProjectsList;
