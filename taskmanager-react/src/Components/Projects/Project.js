import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import { Link } from "react-router-dom";
import ApiController from "../Helpers/ApiController";

class Project extends Component {
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
          <Button
            onClick={() => this.props.deleteItem(this.props.project)}
            bsStyle="danger"
          >
            Delete
          </Button>
        </Link>
      </ButtonToolbar>
    );
  }
}

export default Project;
