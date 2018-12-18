import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import { Link } from "react-router-dom";
import ApiController from "../Helpers/ApiController";

class Project extends Component {
  deleteProject = () => {
    ApiController.api("Projects").delete(this.props.project.id);
    window.location.reload();
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem className="spread">
          {this.props.project.name}
        </ListGroupItem>
        <Link to={`/projects/${this.props.project.id}`}>
          <Button bsStyle="primary">Szczegóły</Button>
        </Link>
        <Link to={"/projects"}>
          <Button onClick={this.deleteProject} bsStyle="danger">
            Usuń
          </Button>
        </Link>
      </ButtonToolbar>
    );
  }
}

export default Project;
