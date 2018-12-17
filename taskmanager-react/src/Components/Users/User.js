import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import UserDetails from "./UserDetails";
import { Link } from "react-router-dom";
import ApiController from "../Helpers/ApiController";

class User extends Component {
  deleteUser = () => {
    ApiController.api("users").delete(this.props.user.id);
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem className="spread">
          {this.props.user.login}
        </ListGroupItem>
        <Link to={`/users/${this.props.user.id}`}>
          <Button bsStyle="primary">Details</Button>
        </Link>
        <Link to={"/users"}>
          <Button onClick={this.deleteUser} bsStyle="danger">
            Delete
          </Button>
        </Link>
      </ButtonToolbar>
    );
  }
}

export default User;
