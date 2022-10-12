import { Observable } from "rxjs";
import { Song } from "src/app/core/models/song.model";
import { SongsService } from "src/app/core/services/data/songs.service";

export interface SongListSpecification {
    get(service: SongsService, count: number, offset: number): Observable<Song[]>;
};
