import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchMoviesDataState {
    movieList: MovieData[];
    loading: boolean;
}

export class FetchMovies extends React.Component<RouteComponentProps<{}>, FetchMoviesDataState> {
    constructor() {
        super();
        this.state = { movieList: [], loading: true };

        fetch('api/Movies/Index')
            .then(response => response.json() as Promise<MovieData[]>)
            .then(data => {
                this.setState({ movieList: data, loading: false });
            });

       // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderMoviesTable(this.state.movieList);

        return <div>
            <h1>Movies Data</h1>
            <p>
                <Link to="/addmovie">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an movie
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete movie with Id: " + id))
            return;
        else {
            fetch('api/Movies/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        movieList: this.state.movieList.filter((rec) => {
                            return (rec.movieId != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/movie/edit/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderMoviesTable(movieList: MovieData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>MoviesId</th>
                    <th>Name</th>
                    <th>GenreId</th>
                </tr>
            </thead>
            <tbody>
                {movieList.map(obj =>
                    <tr key={obj.movieId}>
                        <td></td>
                        <td>{obj.movieId}</td>
                        <td>{obj.name}</td>
                        <td>{obj.genreId}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(obj.movieId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(obj.movieId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class MovieData {
    movieId: number = 0;
    name: string = "";
    genreId: number = 0;
} 