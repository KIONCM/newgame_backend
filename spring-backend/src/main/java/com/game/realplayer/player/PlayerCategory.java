package com.game.realplayer.player;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@NoArgsConstructor
public class PlayerCategory {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
   /* @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(
            name = "categories_players",
            @JoinColumns=@JoinTable(name = "category_id"),
            inverseJoinColumns = @JoinColumn(name = "player_id")
    )
    private List<Player> players;*/
}
