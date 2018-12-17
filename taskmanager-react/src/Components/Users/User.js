import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import UserDetails from "./UserDetails";
import { Route, BrowserRouter } from "react-router-dom";
import { Link } from "react-router-dom";
import ApiController from "../Helpers/ApiController";

class User extends Component {
  deleteUser = () => {
    ApiController.api(
      `https://localhost:44344/api/Users/${this.props.user.id}`
    ).delete();
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem className="spread">
          {this.props.user.login}
        </ListGroupItem>
        <Link to={`/users/${this.props.user.id}`}>
          <Button onClick={this.toggleShowUsers} bsStyle="primary">
            Details
          </Button>
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
