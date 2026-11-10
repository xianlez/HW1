using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatManager : MonoBehaviour
{
    [SerializeField] private float _overlapDistance = 0.3f;
    [SerializeField] private float _interactDistance = 3f;
    [SerializeField] private float _timeBetweenNewMessages = 0.5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private TMP_Text _reactionUiPrefab;

    [SerializeField] private BatW6[] _bats;
    [SerializeField] private string[] _messages;
    [SerializeField] private float[] _newTextTimers;

    private void Start()
    {
        _newTextTimers = new float[_bats.Length];
    }

    private void Update()
    {
        if (_playerTransform == null)
        {
            return;
        }

        for (int i = 0; i < _newTextTimers.Length; i++)
        {
            _newTextTimers[i] += Time.deltaTime;
        }

        for (int i = 0; i < _bats.Length; i++)
        {
            BatW6 bat = _bats[i];
            if (bat == null)
            {
                continue;
            }

            float distance = Vector3.Distance(
                bat.transform.position,
                _playerTransform.position
            );

            if (distance < _interactDistance)
            {
                bat.Chase(_playerTransform);
            }
            else
            {
                bat.StopChasing();
            }

            if (distance < _overlapDistance)
            {
                CreateReactions(bat);
            }
        }
    }

    private void CreateReactions(BatW6 bat)
    {
        if (_messages == null || _messages.Length == 0)
        {
            return;
        }

        int messageIndex = Random.Range(0, _messages.Length);
        SpawnReactionUI(bat, _messages[messageIndex]);
    }

    private void SpawnReactionUI(BatW6 bat, string message)
    {
        int index = System.Array.IndexOf(_bats, bat);
        GridLayoutGroup layout = bat.GetComponentInChildren<GridLayoutGroup>();

        if (layout != null && _reactionUiPrefab != null &&
            _newTextTimers[index] >= _timeBetweenNewMessages)
        {
            _newTextTimers[index] = 0f;
            TMP_Text textObj = Instantiate(_reactionUiPrefab, layout.transform);
            textObj.text = message;
        }
    }
}