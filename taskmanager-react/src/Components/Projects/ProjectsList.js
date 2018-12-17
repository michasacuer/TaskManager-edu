import React, { Component } from "react";
import Project from "./Project";
import { ListGroup } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import axios from "axios";

class ProjectsList extends Component {
  state = {
    projects: []
  };

  componentDidMount() {
    axios.get("https://localhost:44344/api/Projects").then(res => {
      console.log(res);
      this.setState({ projects: res.data });
    });
  }

  render() {
    return (
      <div className="centered">
        {/* <Search projects={this.props.projects} /> */}
        <ListGroup a href="/projects">
          {this.state.projects.map(project => {
            return <Project project={project} key={project.id} />;
          })}
        </ListGroup>
      </div>
    );
  }
}

export default ProjectsList;
