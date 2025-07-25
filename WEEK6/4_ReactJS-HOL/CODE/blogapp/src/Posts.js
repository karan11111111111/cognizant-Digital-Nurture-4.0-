import React, { Component } from 'react';
import Post from './Post';

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      error: null
    };
  }

  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => response.json())
      .then(data => {
        const posts = data.map(post => new Post(post.title, post.body));
        this.setState({ posts });
      })
      .catch(error => {
        this.setState({ error });
        this.componentDidCatch(error, null);
      });
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    alert(`Error occurred: ${error.message}`);
    console.error(error, info);
  }

  render() {
    const { posts, error } = this.state;
    
    if (error) {
      return <div>Error loading posts.</div>;
    }

    return (
      <div className="posts-container">
        <h1>Blog Posts</h1>
        {posts.map((post, index) => (
          <div key={index} className="post">
            <h2>{post.title}</h2>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;