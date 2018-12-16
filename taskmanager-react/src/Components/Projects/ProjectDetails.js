import React, { Component } from "react";
import "../../Styles/Projects.css";

class ProjectDetails extends Component {
  render() {
    return <li>{this.props.project.name}</li>;
  }
}

export default ProjectDetails;
