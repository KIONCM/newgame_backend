package com.game.realplayer.repository;

import com.game.realplayer.entity.Player;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.Optional;

@Repository
@Transactional(readOnly = true)
public interface PlayerRepo extends JpaRepository<Player, Long> {
    Optional<Player> findByEmail(String email);
}
