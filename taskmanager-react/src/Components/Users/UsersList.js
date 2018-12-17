import React, { Component } from "react";
import User from "./User";
import { ListGroup, Button } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";

class UsersList extends Component {
  state = {
    users: []
  };

  componentDidMount() {
    ApiController.api("users")
      .getAll()
      .then(res => {
        console.log(res);
        this.setState({ users: res.data });
      });
  }

  render() {
    return (
      <div className="centered">
        {/* <Search users={this.props.users} /> */}
        <ListGroup a href="/users">
          {this.state.users.map(user => {
            return <User user={user} key={user.id} />;
          })}
        </ListGroup>
        <Button className="succes-button" bsStyle="success">
          Add new user
        </Button>
      </div>
    );
  }
}

export default UsersList;
