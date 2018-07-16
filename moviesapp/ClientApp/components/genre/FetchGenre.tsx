import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchGenresDataState {
    genreList: GenreData[];
    loading: boolean;
}

export class FetchGenres extends React.Component<RouteComponentProps<{}>, FetchGenresDataState> {
    constructor() {
        super();
        this.state = { genreList: [], loading: true };

        fetch('api/Genres/Index')
            .then(response => response.json() as Promise<GenreData[]>)
            .then(data => {
                this.setState({ genreList: data, loading: false });
            });

       // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderGenresTable(this.state.genreList);

        return <div>
            <h1>Genres Data</h1>            
            <p>
                <Link to="/addgenre">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an genre
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete genre with Id: " + id))
            return;
        else {
            fetch('api/Genres/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        genreList: this.state.genreList.filter((rec) => {
                            return (rec.genreId != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/genre/edit/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderGenresTable(genreList: GenreData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>GenresId</th>
                    <th>Name</th>
                    <th>Active</th>
                </tr>
            </thead>
            <tbody>
                {genreList.map(obj =>
                    <tr key={obj.genreId}>
                        <td></td>
                        <td>{obj.genreId}</td>
                        <td>{obj.name}</td>
                        <td>{obj.active}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(obj.genreId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(obj.genreId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class GenreData {
    genreId: number = 0;
    name: string = "";
    active: number = 1;
} 