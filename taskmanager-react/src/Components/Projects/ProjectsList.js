import React, { Component } from "react";
import Project from "./Project";
import { ListGroup, Button } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";

class ProjectsList extends Component {
  state = {
    projects: []
  };

  componentDidMount() {
    ApiController.api("projects")
      .getAll()
      .then(res => {
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
        <Button className="succes-button" bsStyle="success">
          Add new project
        </Button>
      </div>
    );
  }
}

export default ProjectsList;
