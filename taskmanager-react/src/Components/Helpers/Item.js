import React, { Component } from "react";
import { Link } from "react-router-dom";
import { ListGroupItem, Button, ButtonToolbar } from "react-bootstrap";
import "../../Styles/Projects.css";

class Item extends Component {
  render() {
    return (
      <div>
        <ButtonToolbar>
          <ListGroupItem className="spread">{this.props.name}</ListGroupItem>
          <Link to={`/${this.props.items}/${this.props.item.id}`}>
            <Button bsStyle="primary">Details</Button>
          </Link>
          <Link to={`/${this.props.items}`}>
            <Button
              onClick={() => this.props.deleteItem(this.props.item)}
              bsStyle="danger"
            >
              Delete
            </Button>
          </Link>
        </ButtonToolbar>
      </div>
    );
  }
}

export default Item;
