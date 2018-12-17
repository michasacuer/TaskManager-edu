import React, { Component } from "react";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import UserDetails from "./UserDetails";

class User extends Component {
  state = {
    showDetails: false
  };
  constructor(props) {
    super(props);
    this.state = {
      showDetails: false
    };
  }

  toggleShowUsers = () => {
    this.setState(prevState => ({
      showDetails: !prevState.showDetails
    }));
  };

  render() {
    return (
      <ButtonToolbar>
        <ListGroupItem className="spread">
          {this.props.user.login}
        </ListGroupItem>
        <Button onClick={this.toggleShowUsers} bsStyle="primary">
          Details
        </Button>
        {this.state.showDetails && <UserDetails user={this.props.user} />}
      </ButtonToolbar>
    );
  }
}

export default User;
