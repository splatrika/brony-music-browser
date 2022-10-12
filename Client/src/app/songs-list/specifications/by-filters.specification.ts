import { Observable } from "rxjs";
import { SongFilters } from "src/app/core/models/song-filters.model";
import { Song } from "src/app/core/models/song.model";
import { SongsService } from "src/app/core/services/data/songs.service";
import { SongListSpecification } from "../intrefaces/song-list-specification";

export class ByFiltersSpecification implements SongListSpecification {
    constructor (private filters: SongFilters) {}

    get(service: SongsService, count: number, offset: number): Observable<Song[]> {
       return service.getByFilters(this.filters, count, offset);
    }
}