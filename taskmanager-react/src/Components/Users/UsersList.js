import React, { Component } from "react";
import { ListGroup, Button } from "react-bootstrap";
import Search from "../Search";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";
import AddButton from "../Helpers/AddButton";
import Item from "../Helpers/Item";

class UsersList extends Component {
  state = {
    buttonTitle: "Stwórz nowego użytkownika",
    link: "/add/user",
    listOf: "users",
    users: []
  };

  componentDidMount() {
    ApiController.api("Users")
      .getAll()
      .then(res => {
        this.setState({ users: res.data });
      });
  }

  deleteUser = user => {
    ApiController.api(this.state.listOf).delete(user.id);
    window.location.reload();
  };

  render() {
    return (
      <div className="centered">
        {/* <Search users={this.props.users} /> */}
        <ListGroup a="true" href="/users">
          {this.state.users.map(user => {
            return (
              <Item
                item={user}
                name={user.login}
                items={this.state.listOf}
                key={user.id}
                deleteItem={this.deleteUser}
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

export default UsersList;
