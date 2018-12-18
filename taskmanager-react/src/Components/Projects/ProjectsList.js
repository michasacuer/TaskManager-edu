import React, { Component } from "react";
import Project from "./Project";
import { ListGroup, Button } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";
import { Link } from "react-router-dom";

class ProjectsList extends Component {
  state = {
    projects: []
  };

  componentDidMount() {
    ApiController.api("Projects")
      .getAll()
      .then(res => {
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
        <Link to="add/project/">
          <Button className="succes-button" bsStyle="success">
            Dodaj nowy projekt
          </Button>
        </Link>
      </div>
    );
  }
}

export default ProjectsList;
