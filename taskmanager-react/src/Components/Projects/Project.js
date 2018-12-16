import React, { Component } from "react";
import { ListGroupItem } from "react-bootstrap";

class Project extends Component {
  render() {
    return (
      <ListGroupItem href="#link1">{this.props.project.name}</ListGroupItem>
    );
  }
}

export default Project;
