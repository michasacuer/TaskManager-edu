import React, { Component } from "react";
import Project from "./Project";
import { ListGroup } from "react-bootstrap";
import Search from "../Search";

class ProjectsList extends Component {
  render() {
    return (
      <div>
        <Search projects={this.props.projects} />
        <ListGroup>
          {this.props.projects.map(project => {
            return <Project project={project} key={project.id} />;
          })}
        </ListGroup>
      </div>
    );
  }
}

export default ProjectsList;
