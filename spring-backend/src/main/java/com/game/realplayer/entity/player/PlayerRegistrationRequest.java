package com.game.realplayer.entity.player;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.ToString;

@ToString
@AllArgsConstructor
@Data
public class PlayerRegistrationRequest {
    private final String firstname;
    private final String lastname;
    private final String email;
    private final String password;
}
