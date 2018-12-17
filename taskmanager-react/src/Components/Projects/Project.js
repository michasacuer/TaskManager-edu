import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import { Link } from "react-router-dom";
import axios from "axios";

class Project extends Component {
  deleteProject = () => {
    axios
      .delete(`https://localhost:44344/api/Projects/${this.props.project.id}`)
      .then(res => {
        console.log(res);
      });
    window.location.reload();
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem className="spread">
          {this.props.project.name}
        </ListGroupItem>
        <Link to={`/projects/${this.props.project.id}`}>
          <Button bsStyle="primary">Details</Button>
        </Link>
        <Link to={"/projects"}>
          <Button onClick={this.deleteProject} bsStyle="danger">
            Delete
          </Button>
        </Link>
      </ButtonToolbar>
    );
  }
}

export default Project;
