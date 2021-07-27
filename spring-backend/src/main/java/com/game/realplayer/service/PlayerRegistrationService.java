package com.game.realplayer.service;

import com.game.realplayer.entity.player.Player;
import com.game.realplayer.entity.player.PlayerRegistrationRequest;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class PlayerRegistrationService {
    private final PlayerService playerService;

    public String register(PlayerRegistrationRequest request) {
        return playerService.signUp(
                new Player(
                        request.getFirstname(),
                        request.getLastname(),
                        request.getEmail(),
                        request.getPassword()

                )
        );
    }
}
