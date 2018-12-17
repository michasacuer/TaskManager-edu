import React, { Component } from "react";
import User from "./User";
import { ListGroup } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import axios from "axios";

class UsersList extends Component {
  state = {
    users: []
  };

  componentDidMount() {
    axios.get("https://localhost:44344/api/Users").then(res => {
      console.log(res);
      this.setState({ users: res.data });
    });
  }

  render() {
    return (
      <div className="centered">
        <Search users={this.props.users} />
        <ListGroup a href="/users">
          {this.state.users.map(user => {
            return <User user={user} key={user.id} />;
          })}
        </ListGroup>
      </div>
    );
  }
}

export default UsersList;
