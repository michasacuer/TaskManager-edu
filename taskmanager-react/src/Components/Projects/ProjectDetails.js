import React, { Component } from "react";
import "../../Styles/Projects.css";

class ProjectDetails extends Component {
  render() {
    return <li className="text">{this.props.project.description}</li>;
  }
}

export default ProjectDetails;
