import React, { Component } from "react";
import Project from "./Project";
import { ListGroup, Button } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";
import AddButton from "../Helpers/AddButton";
import Item from "../Helpers/Item";

class ProjectsList extends Component {
  state = {
    buttonTitle: "Stwórz nowy projekt",
    link: "/add/project",
    listOf: "projects",
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

  deleteProject = project => {
    ApiController.api(this.state.listOf).delete(project.id);
    window.location.reload();
  };

  render() {
    return (
      <div className="centered">
        {/* <Search projects={this.props.projects} /> */}
        <ListGroup a="true" href="/projects">
          {this.state.projects.map(project => {
            return (
              <Item
                item={project}
                name={project.name}
                items={this.state.listOf}
                key={project.id}
                deleteItem={this.deleteProject}
              />
            );
          })}
        </ListGroup>
        <AddButton
          buttonTitle={this.state.buttonTitle}
          link={this.state.link}
        />
      </div>
    );
  }
}

export default ProjectsList;
